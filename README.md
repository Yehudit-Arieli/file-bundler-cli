# File Bundler CLI

A .NET CLI tool that bundles code files into a single output file and sorts them by file type.

## Overview

This command-line tool recursively scans the current directory, collects code files, and merges them into a single bundle file — saving the effort of manually copying and pasting from multiple files. Build folders (`bin`, `obj`, `debug`) are automatically excluded. Bundling behavior is fully configurable: which languages to include, how to sort the files, whether to strip empty lines, and whether to record each file's source path and an author name as comments.

A second command, `create-rsp`, interactively builds a response file so the full `bundle` command doesn't need to be retyped every time.

Built with the [`System.CommandLine`](https://github.com/dotnet/command-line-api) library.

## Tech Stack

- **Language:** C#
- **Framework:** .NET 8.0
- **Library:** System.CommandLine

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later

### Installation

Clone the repository:

```bash
git clone https://github.com/Yehudit-Arieli/file-bundler-cli.git
cd file-bundler-cli/Cli
```

Build the project:

```bash
dotnet build
```

Optionally, publish the project and add the output folder to your system's `PATH` environment variable, so the tool can be run from any directory without `dotnet run --`.

## Usage

### `bundle` — Bundle code files into a single file

| Option | Alias | Required | Default | Description |
|---|---|---|---|---|
| `--output` | `-o` | No | — | File path and name for the bundled file. |
| `--language` | `-l` | **Yes** | — | Comma-separated list of file extensions to include (e.g. `cs,java`), or `all` to include every file. |
| `--note` | `-n` | No | `false` | Include each file's name as a comment before its content. |
| `--sort` | `-s` | No | `name` | Sort order for bundled files: `name` (alphabetical) or `type` (by extension). |
| `--remove-empty-lines` | `-r` | No | `false` | Remove empty lines from source files before bundling. |
| `--author` | `-a` | No | — | Author name, recorded as a comment at the top of the bundle. |

Example:
```bash
dotnet run -- bundle --output myBundle.txt --language all --note --author "Yehudit"
```

Using short aliases:
```bash
dotnet run -- bundle -o myBundle.txt -l all -n -a "Yehudit"
```

### `create-rsp` — Generate a response file interactively

Prompts for each `bundle` option one at a time, then saves the resulting command into `bundle.rsp`.

```bash
dotnet run -- create-rsp
```

Once created, re-run the same bundle command anytime without retyping it:
```bash
dotnet run -- @bundle.rsp
```

## Project Structure

```
Cli/
├── Cli.csproj          # Project file
├── Program.cs          # Entry point — registers the bundle and create-rsp commands
├── CommandHandler.cs   # Command definitions and bundling logic
├── bundle.rsp          # Example response file
└── myBundle.txt         # Example bundled output
```

## Notes

- Files inside `bin`, `obj`, and `debug` folders are excluded automatically.
- The output file itself is excluded from bundling if it lives in the scanned directory.
- Unrecognized errors during bundling (e.g. an invalid output path) are caught and reported to the console.

## License

This project currently has no license specified.
