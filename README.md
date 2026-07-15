# File Bundler CLI

A .NET CLI tool that bundles code files into a single output file and sorts them by file type.

## Overview

This command-line tool scans a project folder and merges its code files into one bundle file, saving developers the effort of manually copying and pasting from multiple files. The bundling behavior is fully configurable through command-line options — including which languages to include, how to sort the files, whether to strip empty lines, and whether to record the source of each file as a comment.

Built with the [`System.CommandLine`](https://github.com/dotnet/command-line-api) library.

## Features

- Bundle code files from a folder into a single file
- Filter by programming language (or include all files)
- Sort files alphabetically by name or by code type
- Optionally remove empty lines from the source before bundling
- Optionally include a comment noting each file's original path
- Optionally record an author name at the top of the bundle
- Automatically excludes build folders (e.g. `bin`, `debug`)
- Generate a response file (`.rsp`) interactively, so long commands don't need to be retyped

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

Optionally, publish the project and add the output folder to your system's `PATH` environment variable, so the tool can be run from any directory.

## Usage

### `bundle` — Bundle code files into a single file

| Option | Required | Description |
|---|---|---|
| `--language` | Yes | Programming language(s) to include. Use `all` to include every code file regardless of language. |
| `--output` | No | Name or full path of the resulting bundle file. |
| `--note` | No | Include a comment above each file's content noting its original relative path. |
| `--sort` | No | Sort order for bundled files: by file name (default) or by code type. |
| `--remove-empty-lines` | No | Remove empty lines from source files before bundling. |
| `--author` | No | Name of the file's author, recorded as a comment at the top of the bundle. |

Example:
```bash
dotnet run -- bundle --language all --output bundle.txt --note --author "Yehudit"
```

### `create-rsp` — Generate a response file interactively

Running this command prompts you for a value for each `bundle` option one by one, then saves the resulting command into a response file (`.rsp`).

```bash
dotnet run -- create-rsp
```

Once created, the response file can be used to re-run the full bundle command without retyping it:

```bash
dotnet fileName.rsp
```

## Project Structure

```
Cli/
├── Cli.csproj          # Project file
├── Program.cs          # Application entry point and command definitions
├── CommandHandler.cs   # Command parsing and execution logic
├── bundle.rsp          # Example response file
└── myBundle.txt         # Example bundled output
```

## Notes

- Build-related folders (`bin`, `obj`, etc.) are excluded from bundling and from version control.
- Each option has a short alias for convenience when typing commands.
- User input is validated, with clear error messages shown for invalid values.

## License

This project currently has no license specified.
