import speech_recognition as sr
import pyttsx3
import requests

# Initialize text-to-speech engine
engine = pyttsx3.init()

# Initialize speech recognition engine
r = sr.Recognizer()

# Define function to fetch Shabbat timings
def get_shabbat_timings():
    # Send API request to fetch Shabbat timings for current location
    url = "https://www.hebcal.com/leyning?cfg=json&start=2022-09-21&end=2022-09-26"
    response = requests.get(url)
    print(response.content)
    
    # Extract Shabbat timings from API response
    data = response.json()
    items = data.get("items", [])
    if len(items) >= 2:
        candle_lighting = items[0].get("title", "unknown")
        havdalah = items[1].get("title", "unknown")
    else:
        candle_lighting = "unknown"
        havdalah = "unknown"
    
    # Return Shabbat timings as text
    return f"Candle lighting is at {candle_lighting}, and Havdalah is at {havdalah}."

# Define function to speak text
def speak(text):
    engine.say(text)
    engine.runAndWait()

# Define function to listen for voice input
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

# Main loop
while True:
    # Listen for voice input
    text = listen()
    
    # If voice input is detected, fetch Shabbat timings and speak them
    if text:
        if "xyz" in text:
            shabbat_timings = get_shabbat_timings()
            speak(shabbat_timings)
