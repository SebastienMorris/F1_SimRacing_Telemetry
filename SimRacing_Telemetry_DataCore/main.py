# This is a sample Python script.

# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.

import os
import F1server

def say_hello():
    return "Hello world! From python script"


def start_server() -> int:
    F1server.start_server()
    return 0


def stop_server() -> int:
    try:
        F1server.stop_server()
    except:
        return 1
    return 0


def get_server_address() -> tuple[str, int]:
    return F1server.get_server_address()
