# SwapiUI
ASP .Net Core Web application, to fetch Json data from "https://swapi.dev/" API and deserialize it to a Model.

## Languages and Tools:
- C#
- ASP .NET Core
- SWAPI.DEV

## How it works?
- First put a breakpoint at line "people = JsonSerializer.Deserialize<PeopleModel>(responseText);" which is in "Index.cshtml.cs" file, And run IIS Express.
  - You will see the responseText as the Json was fetched from the API, stepover and see people variable.
  
### Sample Response Text:
> {
	"name": "Luke Skywalker",
	"height": "172",
	"mass": "77",
	"hair_color": "blond",
	"skin_color": "fair",
	"eye_color": "blue",
	"birth_year": "19BBY",
	"gender": "male",
	"homeworld": "https://swapi.dev/api/planets/1/",
	"films": [
		"https://swapi.dev/api/films/1/",
		"https://swapi.dev/api/films/2/",
		"https://swapi.dev/api/films/3/",
		"https://swapi.dev/api/films/6/"
	],
	"species": [],
	"vehicles": [
		"https://swapi.dev/api/vehicles/14/",
		"https://swapi.dev/api/vehicles/30/"
	],
	"starships": [
		"https://swapi.dev/api/starships/12/",
		"https://swapi.dev/api/starships/22/"
	],
	"created": "2014-12-09T13:50:51.644000Z",
	"edited": "2014-12-20T21:17:56.891000Z",
	"url": "https://swapi.dev/api/people/1/"
}
