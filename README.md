# Define
A dictionary lookup. Search for words you don't know.

## Example usage

```
> define mire
mire
 noun
 - Deep mud; moist, spongy earth.
 - An undesirable situation, a predicament.
 verb
 - To cause or permit to become stuck in mud; to plunge or fix in mud.
 - To sink into mud.
 - To weigh down.
 - To soil with mud or foul matter.

mire
 noun
 - An ant.

```

## Requirements

- dotnet 8

## Setup

- Run the publish script `./publish`

This will run the publish method. You'll then need to add the build path to your system $PATH variable so that you can call it

- Add the method to you path by adding the following into your ~/.bashrc file. Note that your 

```sh
# Configure define
export PATH="$HOME/projects/define/bin/release/net8.0/linux-x64:$PATH"
```

- Restart your shell then your done
