

var FCKDebug = new Object() ;

FCKDebug._GetWindow = function()
{
	if ( !this.DebugWindow || this.DebugWindow.closed )
		this.DebugWindow = window.open( FCKConfig.BasePath + 'fckdebug.html', 'FCKeditorDebug', 'menubar=no,scrollbars=yes,resizable=yes,location=no,toolbar=no,width=600,height=500', true ) ;

	return this.DebugWindow ;
}

FCKDebug.Output = function( message, color, noParse )
{
	if ( ! FCKConfig.Debug )
		return ;

	try
	{
		this._GetWindow().Output( message, color ) ;
	}
	catch ( e ) {}	 // Ignore errors
}

FCKDebug.OutputObject = function( anyObject, color )
{
	if ( ! FCKConfig.Debug )
		return ;

	try
	{
		this._GetWindow().OutputObject( anyObject, color ) ;
	}
	catch ( e ) {}	 // Ignore errors
}
