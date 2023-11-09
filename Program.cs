using FileGenerator;
using System.CommandLine;

Option<string> outOption = new(
    name: "--out",
    description: "Output directory where files will be generated.")
{
    IsRequired = true,
};

Option<int> fileCountPerDirOption = new(
    name: "--file-number",
    getDefaultValue: () => 400,
    description: "Number of files per dir");

Option<int> fileMaxSizeOption = new(
    name: "--file-max-size",
    getDefaultValue: () => 4_194_304,
    description: "File byte maximum size for generation");

Option<int> dirLevelOptions = new(
    name: "--dir-depth",
    getDefaultValue: () => 2,
    description: "Number of level for sub dirs");

Option<int> dirCountPerDirOptions = new(
    name: "--dir-number",
    getDefaultValue: () => 5,
    description: "Number of dirs per dir");

RootCommand rootCommand = new(
    description: "Small util for generation of rundom test data set for Practice with finding duplicate files")
{
    outOption,
    dirLevelOptions,
    dirCountPerDirOptions,
    fileCountPerDirOption,
    fileMaxSizeOption,
};

rootCommand.SetHandler((dir, level, dirPerDir, filePerDir, fileSize) =>
{
    Generator generator = new()
    {
        DirLevel = level,
        DirCountPerDir = dirPerDir,
        FileCountPerDir = filePerDir,
        FileMaxSizeBytes = fileSize,
    };
    generator.Generate(dir);
},
outOption,
dirLevelOptions,
dirCountPerDirOptions,
fileCountPerDirOption,
fileMaxSizeOption);

await rootCommand.InvokeAsync(args);
