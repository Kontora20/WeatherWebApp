# WeatherWebApp

You can reach access this weather app from https://arnasweather.azurewebsites.net/.
Written with .NET 5 + Blazor, hosted to Azure with Github Actions CI/CD.

Note:
There's a bug involving Blazor and rendering with OnInitializedAsync() - it's called twice for some reason. Trying to to change the render-mode from "ServerPrerendered" to "Server" does fix the issue.
Due to the bug, all of the content is being rendered twice and there's two weather components appearing in the same page. Sorry. Hopefully this can be fixed withing Q3 if stakeholders approve.
