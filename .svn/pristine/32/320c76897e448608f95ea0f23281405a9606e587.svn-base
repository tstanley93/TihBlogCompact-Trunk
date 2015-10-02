

var FCKXml = function()
{
	this.Error = false ;
}

FCKXml.GetAttribute = function( node, attName, defaultValue )
{
	var attNode = node.attributes.getNamedItem( attName ) ;
	return attNode ? attNode.value : defaultValue ;
}

/**
 * Transforms a XML element node in a JavaScript object. Attributes defined for
 * the element will be available as properties, as long as child  element
 * nodes, but the later will generate arrays with property names prefixed with "$".
 *
 * For example, the following XML element:
 *
 *		<SomeNode name="Test" key="2">
 *			<MyChild id="10">
 *				<OtherLevel name="Level 3" />
 *			</MyChild>
 *			<MyChild id="25" />
 *			<AnotherChild price="499" />
 *		</SomeNode>
 *
 * ... results in the following object:
 *
 *		{
 *			name : "Test",
 *			key : "2",
 *			$MyChild :
 *			[
 *				{
 *					id : "10",
 *					$OtherLevel :
 *					{
 *						name : "Level 3"
 *					}
 *				},
 *				{
 *					id : "25"
 *				}
 *			],
 *			$AnotherChild :
 *			[
 *				{
 *					price : "499"
 *				}
 *			]
 *		}
 */
FCKXml.TransformToObject = function( element )
{
	if ( !element )
		return null ;

	var obj = {} ;

	var attributes = element.attributes ;
	for ( var i = 0 ; i < attributes.length ; i++ )
	{
		var att = attributes[i] ;
		obj[ att.name ] = att.value ;
	}

	var childNodes = element.childNodes ;
	for ( i = 0 ; i < childNodes.length ; i++ )
	{
		var child = childNodes[i] ;

		if ( child.nodeType == 1 )
		{
			var childName = '$' + child.nodeName ;
			var childList = obj[ childName ] ;
			if ( !childList )
				childList = obj[ childName ] = [] ;

			childList.push( this.TransformToObject( child ) ) ;
		}
	}

	return obj ;
}
