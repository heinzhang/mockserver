# mockserver
a c# mock server to return the status code and request details in separated log file for different users. 

## how to use 

Test http code
Send request to 
http://localhost:{port}/api/httpcode/{logfilename}/{statuscode}
example:
http://localhost:8439/api/httpcode/mytestlog/200

This will return status code 200 and write the request header and response in mytestlog.log on D drive (todo: use relative path). 

Empty log file
http://localhost:{port}/api/httpcode/{logfilename}/666

