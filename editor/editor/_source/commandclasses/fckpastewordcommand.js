﻿

var FCKPasteWordCommand = function()
{
	this.Name = 'PasteWord' ;
}

FCKPasteWordCommand.prototype.Execute = function()
{
	FCK.PasteFromWord() ;
}

FCKPasteWordCommand.prototype.GetState = function()
{
	if ( FCK.EditMode != FCK_EDITMODE_WYSIWYG || FCKConfig.ForcePasteAsPlainText )
		return FCK_TRISTATE_DISABLED ;
	else
		return FCK.GetNamedCommandState( 'Paste' ) ;
}
