# FileGenerator

Small util for generation of test data set for Practice with finding duplicate files.

## Requirements

- [net7.0 sdk](https://www.microsoft.com/net/download)

## Tool API
```bash
Usage:
  FileGenerator [options]

Options:
  --out <out> (REQUIRED)           Output directory where files will be generated.
  --dir-depth <dir-depth>          Number of level for sub dirs [default: 2]
  --dir-number <dir-number>        Number of dirs per dir [default: 5]
  --file-number <file-number>      Number of files per dir [default: 400]
  --file-max-size <file-max-size>  File byte maximum size for generation [default: 4194304]
  --version                        Show version information
  -?, -h, --help                   Show help and usage information
```

## Build

```bash

dotnet build

```

## Run

```bash

dotnet run -- -h

```