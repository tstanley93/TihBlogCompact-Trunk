#!/usr/bin/env python

"""
"""

from connector import FCKeditorConnector
from upload import FCKeditorQuickUpload

import cgitb
from cStringIO import StringIO

# Running from WSGI capable server (recomended)
def App(environ, start_response):
	"WSGI entry point. Run the connector"
	if environ['SCRIPT_NAME'].endswith("connector.py"):
		conn = FCKeditorConnector(environ)
	elif environ['SCRIPT_NAME'].endswith("upload.py"):
		conn = FCKeditorQuickUpload(environ)
	else:
		start_response ("200 Ok", [('Content-Type','text/html')])
		yield "Unknown page requested: "
		yield environ['SCRIPT_NAME']
		return
	try:
		# run the connector
		data = conn.doResponse()
		# Start WSGI response:
		start_response ("200 Ok", conn.headers)
		# Send response text
		yield data
	except:
		start_response("500 Internal Server Error",[("Content-type","text/html")])
		file = StringIO()
		cgitb.Hook(file = file).handle()
		yield file.getvalue()
