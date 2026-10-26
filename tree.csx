using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

static class Log
{
    static void Write(ConsoleColor color, string prefix, string msg)
    {
        var prev = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write($"[{prefix}] ");
        Console.ForegroundColor = prev;
        Console.WriteLine(msg);
    }
    public static void Info(string msg) => Write(ConsoleColor.Gray, "INFO", msg);
    public static void Error(string msg) => Write(ConsoleColor.Red, "ERROR", msg);
    public static void Warn(string msg) => Write(ConsoleColor.Yellow, "WARN", msg);
    public static void Success(string msg) => Write(ConsoleColor.Green, "OK", msg);
    public static void Raw(string msg) => Console.WriteLine(msg);
}

public class Tree
{
    private static readonly HashSet<string> IgnoredNames = new HashSet<string>
    {
        ".git", ".scriptcs_cache", ".vs", ".vscode", "node_modules", "compiled"
    };

    private static int totalDirs = 0;
    private static int totalFiles = 0;

    public static void Main(string[] args)
    {
        string targetDir = args.Length > 0 ? args[0] : Environment.CurrentDirectory;
        string resolvedDir = Path.GetFullPath(targetDir);

        Log.Raw(resolvedDir);

        try
        {
            FileAttributes attr = File.GetAttributes(resolvedDir);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                totalDirs++; // Count the root directory itself
                GenerateTree(resolvedDir, "");
            }
            else
            {
                Log.Error($"Error: {resolvedDir} is not a directory.");
                Environment.Exit(1);
            }
        }
        catch (Exception ex)
        {
            Log.Error($"Error: Could not access {resolvedDir}. {ex.Message}");
            Environment.Exit(1);
        }

        Log.Raw($"\n{totalDirs} directories, {totalFiles} files");
    }

    private static void GenerateTree(string dirPath, string prefix)
    {
        string[] items;
        try
        {
            items = Directory.GetFileSystemEntries(dirPath);
        }
        catch (UnauthorizedAccessException)
        {
            // Console.WriteLine($"Access denied to {dirPath}");
            return;
        }
        catch (DirectoryNotFoundException)
        {
            // Console.WriteLine($"Directory not found: {dirPath}");
            return;
        }
        catch (Exception ex)
        {
            // Console.WriteLine($"Error reading directory {dirPath}: {ex.Message}");
            return;
        }

        var filteredItems = items
            .Select(item => Path.GetFileName(item))
            .Where(item => !IgnoredNames.Contains(item))
            .ToList();

        for (int i = 0; i < filteredItems.Count; i++)
        {
            string item = filteredItems[i];
            string itemPath = Path.Combine(dirPath, item);
            bool isLast = i == filteredItems.Count - 1;
            string connector = isLast ? "└── " : "├── ";

            Log.Raw(prefix + connector + item);

            try
            {
                FileAttributes attr = File.GetAttributes(itemPath);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    totalDirs++;
                    string newPrefix = prefix + (isLast ? "    " : "│   ");
                    GenerateTree(itemPath, newPrefix);
                }
                else
                {
                    totalFiles++;
                }
            }
            catch (FileNotFoundException)
            {
                // Item might have been deleted between GetFileSystemEntries and GetAttributes
            }
            catch (DirectoryNotFoundException)
            {
                // Item might have been deleted between GetFileSystemEntries and GetAttributes
            }
            catch (UnauthorizedAccessException)
            {
                // Access denied to this specific item
            }
            catch (Exception ex)
            {
                // Console.WriteLine($"Error stating item {itemPath}: {ex.Message}");
            }
        }
    }
}
