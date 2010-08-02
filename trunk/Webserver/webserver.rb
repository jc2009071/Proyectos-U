# Universidad del Valle de Guatemala
# Sistemas Operativos Avanzados
# Luis Carlos Aldana 08261

require 'socket'

server = TCPServer.open(8081)

loop{

  client = server.accept
	client.print "HTTP/1.1 200/OK\r\nContent-type:text/html\r\n\r\n"

	request = client.gets
	validGet = request.match(/GET .* HTTP\/1\.1/)

  unless (validGet)
    client.puts "HTTP/1.1 400 Bad Request"
    client.close
    next
  end

    # cambiar a E: si esta en la laptop
	filename = "D:\\My Dropbox\\UVG\\Sistemas Operativos\\Proy0\\respuesta.html" 

	begin
		displayfile = File.open(filename, 'r')
		content = displayfile.read()
		client.print content
	rescue Errno::ENOENT
		client.print "File not found"
	end

	client.close
}
