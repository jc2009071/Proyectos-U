'''text = "GET /index.html HTTP/1.1"

# a string of digits
m = re.match("GET .* HTTP/1\.1", text)
if m: print repr("\d+"), "=>", repr(m.group(0))
else: print "no hizo match"'''
# http://www.wellho.net/resources/ex.php4?item=y202/pyserv
# Basic web server

import socket
import re

def matchesGet(text):
    m = re.match("GET .* HTTP/1\.1", text)
    if m:
        print repr(m.group(0))
        return True
    else:
        return False

host = ''
port = 8082

sock = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
sock.setsockopt(socket.SOL_SOCKET,socket.SO_REUSEADDR,1)
sock.bind((host,port))
sock.listen(1)

while 1:
    csock,caddr = sock.accept()
    cfile = csock.makefile('rw',0)

    cfile.write("HTTP/1.1 200/OK\r\nContent-type:text/html\r\n\r\n")
    
    request = cfile.readline().strip()

    if request == False:
        break

    isValidRequest = matchesGet(request)
    print "Request: ",request,"isValidRequest:",isValidRequest
    
    if isValidRequest:
        pass
    else:
        cfile.write("HTTP/1.1 400 Bad Request")


    line = cfile.readline().strip()
    try:
        print "tratando de imprimir html"
        #content = open("D:\\My Dropbox\\UVG\\Sistemas Operativos\\Proy0\\respuesta.html","r").read()
        content = "<html><body><h1>hola!</h1></body></html>"
        print content
        cfile.write(content)
    except:
        print "File not found"
        cfile.write("File not Found")

    cfile.close()
    csock.close()
    
