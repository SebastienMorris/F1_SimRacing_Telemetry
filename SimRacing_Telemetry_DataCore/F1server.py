import socket
import threading
import queue
from queue import Queue

PORT = 6767
IP = socket.gethostbyname(socket.gethostname())
server = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
server.bind((IP, PORT))
server.settimeout(0.2)

runServer : bool = False;
messages : Queue = queue.Queue()
receiveThread : Thread = None
handleThread : Thread = None


def receive_messages():
    global runServer

    runServer = True
    while runServer:
        try:
            message = server.recvfrom(1024)[0].decode('utf-8')
            messages.put(message)
        except:
            pass


def handle_messages():
    global runServer

    while runServer:
        while not messages.empty():
            message = messages.get()
            print("Data received: " + message)


def start_server():
    global runServer, receiveThread, handleThread

    if(runServer):
        return

    runServer = True
    receiveThread = threading.Thread(target=receive_messages)
    handleThread = threading.Thread(target=handle_messages)

    receiveThread.start()
    handleThread.start()
    print("Server started")


def stop_server():
    global runServer

    runServer = False
    if(receiveThread != None and handleThread != None):
        receiveThread.join()
        receiveThread = None
        handleThread.join()
        handleThread = None

    server.close();
    print("Server stopped")


def get_server_address() -> tuple[str, int]:
    return IP, PORT

