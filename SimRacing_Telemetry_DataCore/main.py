# This is a sample Python script.

# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.

import os
import F1server

def say_hello():
    return "Hello world! From python script"


def start_server() -> int:
    try:
        F1server.start_server()
    except:
        return 1
    return 0


def stop_server() -> int:
    try:
        F1server.stop_server()
    except:
        return 1
    return 0


def get_server_address() -> tuple[str, int]:
    return F1server.get_server_address()

def get_race_data(raceName : string) -> dict[string, dict[string, string]]:
    data : dict[string, dict[string, string]] = {
        "Lap" : {
            "laptime" : "01:10:100",
            "current position" : "5",
            "tyre compound" : "Hard",
            "tyre age" : "10"
        },
        "Result" : {
            "final position" : "1",
            "total overtakes" : "20",
            "number of stops" : "2"
        }
    }
    return data;
