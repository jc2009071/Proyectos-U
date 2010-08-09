import socket
import re

def matchesGet(text):
    m = re.match("GET .* HTTP/1\.1", text)
    if m:
        print repr(m.group(0))
        return True
    else:
        return False

#initialize socket
host = ''
port = 8082

server = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
server.setsockopt(socket.SOL_SOCKET,socket.SO_REUSEADDR,1)
server.bind((host,port))
server.listen(1)

#infinite loop
while 1:
    clientSock,clientAddr = server.accept() #accept connection
    clientFile = clientSock.makefile('rw',0) #creates comunication file

    clientFile.write("HTTP/1.1 200/OK\r\nContent-type:text/html\r\n\r\n")
    # send expected file size?
    request = clientFile.readline().strip()
    if request == False:
        break

    isValidRequest = matchesGet(request)
    if isValidRequest: #validates request
        pass
    else:
        clientFile.write("HTTP/1.1 400 Bad Request")

    try:
        content = open("/root/proy/respuesta.html","r").read()
        clientFile.write(content) #send html file
    except:
        clientFile.write("File not Found")

    #close connection
    clientFile.close()
    clientSock.close()
