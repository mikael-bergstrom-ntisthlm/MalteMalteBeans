using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

public class Sheets : MonoBehaviour
{
    private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
    private const string SpreadsheetId = "1xZ1zdkaZuf-WtXWAGy03M6xWpYWeTgZREHzNvTDcp90";
    private const string GoogleCredentialsFileName = "google-credentials.json";

    void Start()
    {
        
    }

    public void Write(string number, string burk_number) {

    }

    private static SheetsService GetSheetsService()
    {

        using (var stream = new FileStream(GoogleCredentialsFileName, FileMode.Open, FileAccess.Read))
        {
            var serviceInitializer = new BaseClientService.Initializer
            {
                HttpClientInitializer = GoogleCredential
                HttpClientInitializer = GoogleCredential.FromStream(stream).CreateScoped(Scopes)
            };
        return new SheetsService(serviceInitializer);
    }

}

namespace GoogleApiExample
{
    class Program
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private const string SpreadsheetId = "1bSU7TCa8xOiBlaWf2qncewyMUclO1HzEyiSzAs0Tqqw";
        private const string GoogleCredentialsFileName = "google-credentials.json";
        /*
           Sheet1 - tab name in a spreadsheet
           A:B     - range of values we want to receive
        */
        private const string ReadRange = "Sheet1!A:B";
        static async Task Main(string[] args)
        {
            var serviceValues = GetSheetsService().Spreadsheets.Values;
            await ReadAsync(serviceValues);
        }
        
       private static async Task ReadAsync(SpreadsheetsResource.ValuesResource valuesResource)
       {
            var response = await valuesResource.Get(SpreadsheetId, ReadRange).ExecuteAsync();
            var values = response.Values;
            if (values == null || !values.Any())
            {
                 Console.WriteLine("No data found.");
                 return;
            }
             var header = string.Join(" ", values.First().Select(r => r.ToString()));
             Console.WriteLine($"Header: {header}");
 
             foreach (var row in values.Skip(1))
             {
                 var res = string.Join(" ", row.Select(r => r.ToString()));
                 Console.WriteLine(res);
             }
        }
    }
}