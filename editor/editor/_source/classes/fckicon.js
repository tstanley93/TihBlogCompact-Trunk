﻿

var FCKIcon = function( iconPathOrStripInfoArray )
{
	var sTypeOf = iconPathOrStripInfoArray ? typeof( iconPathOrStripInfoArray ) : 'undefined' ;
	switch ( sTypeOf )
	{
		case 'number' :
			this.Path = FCKConfig.SkinPath + 'fck_strip.gif' ;
			this.Size = 16 ;
			this.Position = iconPathOrStripInfoArray ;
			break ;

		case 'undefined' :
			this.Path = FCK_SPACER_PATH ;
			break ;

		case 'string' :
			this.Path = iconPathOrStripInfoArray ;
			break ;

		default :
			// It is an array in the format [ StripFilePath, IconSize, IconPosition ]
			this.Path		= iconPathOrStripInfoArray[0] ;
			this.Size		= iconPathOrStripInfoArray[1] ;
			this.Position	= iconPathOrStripInfoArray[2] ;
	}
}

FCKIcon.prototype.CreateIconElement = function( document )
{
	var eIcon, eIconImage ;

	if ( this.Position )		// It is using an icons strip image.
	{
		var sPos = '-' + ( ( this.Position - 1 ) * this.Size ) + 'px' ;

		if ( FCKBrowserInfo.IsIE )
		{
			// <div class="TB_Button_Image"><img src="strip.gif" style="top:-16px"></div>

			eIcon = document.createElement( 'DIV' ) ;

			eIconImage = eIcon.appendChild( document.createElement( 'IMG' ) ) ;
			eIconImage.src = this.Path ;
			eIconImage.style.top = sPos ;
		}
		else
		{
			// <img class="TB_Button_Image" src="spacer.gif" style="background-position: 0px -16px;background-image: url(strip.gif);">

			eIcon = document.createElement( 'IMG' ) ;
			eIcon.src = FCK_SPACER_PATH ;
			eIcon.style.backgroundPosition	= '0px ' + sPos ;
			eIcon.style.backgroundImage		= 'url("' + this.Path + '")' ;
		}
	}
	else					// It is using a single icon image.
	{
		if ( FCKBrowserInfo.IsIE )
		{
			// IE makes the button 1px higher if using the <img> directly, so we
			// are changing to the <div> system to clip the image correctly.
			eIcon = document.createElement( 'DIV' ) ;

			eIconImage = eIcon.appendChild( document.createElement( 'IMG' ) ) ;
			eIconImage.src = this.Path ? this.Path : FCK_SPACER_PATH ;
		}
		else
		{
			// This is not working well with IE. See notes above.
			// <img class="TB_Button_Image" src="smiley.gif">
			eIcon = document.createElement( 'IMG' ) ;
			eIcon.src = this.Path ? this.Path : FCK_SPACER_PATH ;
		}
	}

	eIcon.className = 'TB_Button_Image' ;

	return eIcon ;
}
