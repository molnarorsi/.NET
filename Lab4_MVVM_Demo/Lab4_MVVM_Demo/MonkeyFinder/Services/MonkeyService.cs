﻿using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    private HttpClient httpClient;
    private List<Monkey> monkeyList = new();

    public MonkeyService()
    {
        this.httpClient = new HttpClient();
    }

    
    public async Task<List<Monkey>> GetMonkeys()
    {
        if (monkeyList?.Count > 0)
            return monkeyList;

        var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
        if (response.IsSuccessStatusCode)
        {
            //ez van online
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }
        else
        {
            //offline
            using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);
        }

        return monkeyList;
    }
}
