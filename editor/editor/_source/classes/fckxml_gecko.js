
FCKXml.prototype =
{
	LoadUrl : function( urlToCall )
	{
		this.Error = false ;

		var oXml ;
		var oXmlHttp = FCKTools.CreateXmlObject( 'XmlHttp' ) ;
		oXmlHttp.open( 'GET', urlToCall, false ) ;
		oXmlHttp.send( null ) ;

		if ( oXmlHttp.status == 200 || oXmlHttp.status == 304 )
			oXml = oXmlHttp.responseXML ;
		else if ( oXmlHttp.status == 0 && oXmlHttp.readyState == 4 )
			oXml = oXmlHttp.responseXML ;
		else
			oXml = null ;

		if ( oXml )
		{
			// Try to access something on it.
			try
			{
				var test = oXml.firstChild ;
			}
			catch (e)
			{
				// If document.domain has been changed (#123), we'll have a security
				// error at this point. The workaround here is parsing the responseText:
				// http://alexander.kirk.at/2006/07/27/firefox-15-xmlhttprequest-reqresponsexml-and-documentdomain/
				oXml = (new DOMParser()).parseFromString( oXmlHttp.responseText, 'text/xml' ) ;
			}
		}

		if ( !oXml || !oXml.firstChild )
		{
			this.Error = true ;
			if ( window.confirm( 'Error loading "' + urlToCall + '" (HTTP Status: ' + oXmlHttp.status + ').\r\nDo you want to see the server response dump?' ) )
				alert( oXmlHttp.responseText ) ;
		}

		this.DOMDocument = oXml ;
	},

	SelectNodes : function( xpath, contextNode )
	{
		if ( this.Error )
			return new Array() ;

		var aNodeArray = new Array();

		var xPathResult = this.DOMDocument.evaluate( xpath, contextNode ? contextNode : this.DOMDocument,
				this.DOMDocument.createNSResolver(this.DOMDocument.documentElement), XPathResult.ORDERED_NODE_ITERATOR_TYPE, null) ;
		if ( xPathResult )
		{
			var oNode = xPathResult.iterateNext() ;
			while( oNode )
			{
				aNodeArray[aNodeArray.length] = oNode ;
				oNode = xPathResult.iterateNext();
			}
		}
		return aNodeArray ;
	},

	SelectSingleNode : function( xpath, contextNode )
	{
		if ( this.Error )
			return null ;

		var xPathResult = this.DOMDocument.evaluate( xpath, contextNode ? contextNode : this.DOMDocument,
				this.DOMDocument.createNSResolver(this.DOMDocument.documentElement), 9, null);

		if ( xPathResult && xPathResult.singleNodeValue )
			return xPathResult.singleNodeValue ;
		else
			return null ;
	}
} ;
