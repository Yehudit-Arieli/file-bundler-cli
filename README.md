# File Bundler CLI

A .NET CLI tool that bundles multiple source code files into a single output file with configurable filtering, sorting, and formatting options.

## Overview

This command-line tool recursively scans a project directory, collects source code files, and combines them into a single output file. Generated folders (`bin`, `obj`, and `debug`) are automatically excluded.

The bundling process is configurable, allowing you to:

- filter files by programming language
- sort files by name or file type
- remove empty lines
- include source file names as comments
- add author information to the generated file

The project also includes a `create-rsp` command that interactively generates a response file, making repeated executions much more convenient.

Built with the [`System.CommandLine`](https://github.com/dotnet/command-line-api) library.

## Features

- Bundle multiple source files into a single output file
- Filter by programming language
- Sort files by name or type
- Automatically ignore `bin`, `obj`, and `debug` folders
- Remove empty lines
- Include source file names as comments
- Add author information
- Generate reusable response files (`bundle.rsp`)

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
├── Program.cs          # Application entry point
├── CommandHandler.cs   # Command definitions and business logic
├── Cli.csproj
├── bundle.rsp          # Sample response file
└── myBundle.txt        # Sample bundled output
```

## Notes

- Files inside `bin`, `obj`, and `debug` folders are excluded automatically.
- The output file itself is excluded from bundling if it lives in the scanned directory.
- Unrecognized errors during bundling (e.g. an invalid output path) are caught and reported to the console.

## License

This project is intended for educational purposes.
