import requests
import speech_recognition as sr
import pyttsx3
from geopy.geocoders import Nominatim
def get_coordinates(city):
    geolocator = Nominatim(user_agent="geoapiExercises")
    location = geolocator.geocode(city)
    if location is not None:
        latitude = location.latitude
        longitude = location.longitude
        return latitude, longitude
    else:
        return None
def get_shabbat_timings(latitude, longitude):
    url = f"https://www.hebcal.com/shabbat?cfg=json&geo=pos&latitude={latitude}&longitude={longitude}"
    response = requests.get(url)
    data = response.json()
    candle_lighting = data["items"][0]["title"]
    havdalah = data["items"][3]["title"]
    return f"{candle_lighting}, {havdalah}."
def speak(text):
    engine.say(text)
    engine.runAndWait()
def listen():
    with sr.Microphone() as source:
        print("Listening...")
        audio = r.listen(source)
    try:
        text = r.recognize_google(audio)
        #print(f"You said: {text}")
        return text
    except:
        print("Sorry, I didn't catch that.")
        return None
engine = pyttsx3.init()
# Initialize speech recognition engine
r = sr.Recognizer()
# Example usage:

i=5
while i>0:
    text = listen()
    #text = text.lower()
    i -= 1
    if text:
        if "time in" in text:
            city = text.split("in ")[1]
            coordinates = get_coordinates(city)
            if coordinates is not None:
                latitude, longitude = coordinates
                shabbat_timings = get_shabbat_timings(latitude,longitude)
                print(f"Shabbat time in {city} is:")
                print(f"{shabbat_timings}")
                speak(shabbat_timings)
            else:
                print(f"Could not find coordinates for {city}")
                speak(f"Could not find coordinates for {city}")
