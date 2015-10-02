

FCKTableHandler.GetSelectedCells = function()
{
	if ( FCKSelection.GetType() == 'Control' )
	{
		var td = FCKSelection.MoveToAncestorNode( 'TD' ) ;
		return td ? [ td ] : [] ;
	}

	var aCells = new Array() ;

	var oRange = FCKSelection.GetSelection().createRange() ;
//	var oParent = oRange.parentElement() ;
	var oParent = FCKSelection.GetParentElement() ;

	if ( oParent && oParent.tagName.Equals( 'TD', 'TH' ) )
		aCells[0] = oParent ;
	else
	{
		oParent = FCKSelection.MoveToAncestorNode( 'TABLE' ) ;

		if ( oParent )
		{
			// Loops throw all cells checking if the cell is, or part of it, is inside the selection
			// and then add it to the selected cells collection.
			for ( var i = 0 ; i < oParent.cells.length ; i++ )
			{
				var oCellRange = FCK.EditorDocument.body.createTextRange() ;
				oCellRange.moveToElementText( oParent.cells[i] ) ;

				if ( oRange.inRange( oCellRange )
					|| ( oRange.compareEndPoints('StartToStart',oCellRange) >= 0 &&  oRange.compareEndPoints('StartToEnd',oCellRange) <= 0 )
					|| ( oRange.compareEndPoints('EndToStart',oCellRange) >= 0 &&  oRange.compareEndPoints('EndToEnd',oCellRange) <= 0 ) )
				{
					aCells[aCells.length] = oParent.cells[i] ;
				}
			}
		}
	}

	return aCells ;
}
