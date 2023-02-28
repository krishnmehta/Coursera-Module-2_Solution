import requests
from bs4 import BeautifulSoup

def get_shabbat_timings():
    # Send GET request to fetch Shabbat timings from webpage
    url = "https://www.hebcal.com/shabbat"
    response = requests.get(url)
    
    # Extract Shabbat timings from webpage
    soup = BeautifulSoup(response.content, "html.parser")
    candle_lighting = soup.find_all("span", {"class": "h2 hebcal-event-title"})[0].text
    havdalah = soup.find_all("span", {"class": "h2 hebcal-event-title"})[1].text
    
    # Return Shabbat timings as text
    return f"Candle lighting is at {candle_lighting}, and Havdalah is at {havdalah}."

# Example usage:
shabbat_timings = get_shabbat_timings()
print(shabbat_timings)
