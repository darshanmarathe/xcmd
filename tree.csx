using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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

        Console.WriteLine(resolvedDir);

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
                Console.WriteLine($"Error: {resolvedDir} is not a directory.");
                Environment.Exit(1);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: Could not access {resolvedDir}. {ex.Message}");
            Environment.Exit(1);
        }

        Console.WriteLine($"\n{totalDirs} directories, {totalFiles} files");
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

            Console.WriteLine(prefix + connector + item);

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
