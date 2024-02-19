using System.Text.Json;

var words = Environment.GetCommandLineArgs().ToList().Skip(1).Where(x => !String.IsNullOrEmpty(x));

foreach (var word in words)
{
	try {
		var response = await getDictionaryResponse(word);
		foreach (var wordResponse in response) {
			printWordAndPhonetic(wordResponse.word, wordResponse.phonetic);

			foreach (var meaning in wordResponse.meanings) {
				printPartOfSpeech(meaning.partOfSpeech);
				foreach (var definition in meaning.definitions) {
					printDefinition(definition.definition);
				}
			}
			Console.WriteLine();
		}
	} catch {
		Console.ForegroundColor = ConsoleColor.DarkRed;
		Console.WriteLine($"Failed to lookup word: {word}");
		Console.ResetColor();
	}
}

async Task<List<WordResponse>> getDictionaryResponse(string word) {
	HttpClient client = new();
	var search = $"https://api.dictionaryapi.dev/api/v2/entries/en/{word}";
	var response = await client.GetAsync(search);
	response.EnsureSuccessStatusCode();
	var stream = await response.Content.ReadAsStreamAsync();
	var result = await JsonSerializer.DeserializeAsync<List<WordResponse>>(stream);
	if (result == null) throw new Exception("Something wen't wrong!");
	return result;
}

void printPartOfSpeech(string partOfSpeech) {
	Console.ForegroundColor = ConsoleColor.Magenta;
	Console.WriteLine($" {partOfSpeech}");
	Console.ResetColor();
}

void printWordAndPhonetic(string word, string phonetic) {
	Console.ForegroundColor = ConsoleColor.Blue;
	Console.Write($"{word} ");
	Console.ForegroundColor = ConsoleColor.DarkGray;
	Console.WriteLine(phonetic);
	Console.ResetColor();
}

void printDefinition(string definition) {
	Console.ForegroundColor = ConsoleColor.Gray;
	Console.WriteLine($" - {definition}");
	Console.ResetColor();
}

public record class WordResponse(string word, string phonetic, List<Meaning> meanings);
public record class Meaning(string partOfSpeech, List<Definition> definitions);
public record class Definition(string definition, List<string> synonyms, List<string> antonyms);
