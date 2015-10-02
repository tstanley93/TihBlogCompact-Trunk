

sub CreateXmlHeader
{
	local($command,$resourceType,$currentFolder) = @_;

	# Create the XML document header.
	print '<?xml version="1.0" encoding="utf-8" ?>';

	# Create the main "Connector" node.
	print '<Connector command="' . $command . '" resourceType="' . $resourceType . '">';

	# Add the current folder node.
	print '<CurrentFolder path="' . ConvertToXmlAttribute($currentFolder) . '" url="' . ConvertToXmlAttribute(GetUrlFromPath($resourceType,$currentFolder)) . '" />';
}

sub CreateXmlFooter
{
	print '</Connector>';
}

sub SendError
{
	local( $number, $text ) = @_;

	print << "_HTML_HEAD_";
Content-Type:text/xml; charset=utf-8
Pragma: no-cache
Cache-Control: no-cache
Expires: Thu, 01 Dec 1994 16:00:00 GMT

_HTML_HEAD_

	# Create the XML document header
	print '<?xml version="1.0" encoding="utf-8" ?>' ;

	print '<Connector><Error number="' . $number . '" text="' . &specialchar_cnv( $text ) . '" /></Connector>' ;

	exit ;
}

1;
