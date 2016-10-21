# WeatherReport

Welcome to the WeatherReport app.

Using WeatherReport is simple. Just enter a location and 
current conditions and an extended forecast will be provided
for the location entered.

The following API's were used for WeatherReport:
Google Maps GeoCoding API: https://developers.google.com/maps/documentation/geocoding/intro

Dark Sky API: https://darksky.net/dev/

This app uses the Google Maps GeoCoding API to search for the location entered by the
user. The app then uses the latitude and longitude data obtained from this search
to receive weather data at those coordinates which is then displayed to the user.
