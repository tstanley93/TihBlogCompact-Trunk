

var FCKDocumentFragment = function( parentDocument, baseDocFrag )
{
	this.RootNode = baseDocFrag || parentDocument.createDocumentFragment() ;
}

FCKDocumentFragment.prototype =
{

	// Append the contents of this Document Fragment to another element.
	AppendTo : function( targetNode )
	{
		targetNode.appendChild( this.RootNode ) ;
	},

	InsertAfterNode : function( existingNode )
	{
		FCKDomTools.InsertAfterNode( existingNode, this.RootNode ) ;
	}
}
