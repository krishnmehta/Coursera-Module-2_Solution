import requests
import speech_recognition as sr
import pyttsx3

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
        print(f"You said: {text}")
        return text
    except:
        print("Sorry, I didn't catch that.")
        return None


engine = pyttsx3.init()

# Initialize speech recognition engine
r = sr.Recognizer()
from geopy.geocoders import Nominatim

# Initialize Nominatim API
geolocator = Nominatim(user_agent="geoapiExercises")

# Get location using current address
location = geolocator.geocode("current location")

# Example usage:
while True:
    text = listen()
    if text:
        if "xyz" in text:
            latitude = 22.310696
            longitude = 73.192635
            shabbat_timings = get_shabbat_timings(latitude,longitude)
            print(f"{shabbat_timings}")
            speak(shabbat_timings)
# latitude = 22.310696
# longitude = 73.192635
# #timezone = ""
# shabbat_timings = get_shabbat_timings(latitude, longitude)
# print(shabbat_timings)
