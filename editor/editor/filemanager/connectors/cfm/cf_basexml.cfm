<cfsetting enablecfoutputonly="Yes">


<cffunction name="SetXmlHeaders" returntype="void">
	<cfheader name="Expires" value="#GetHttpTimeString(Now())#">
	<cfheader name="Pragma" value="no-cache">
	<cfheader name="Cache-Control" value="no-cache, no-store, must-revalidate">
	<cfcontent reset="true" type="text/xml; charset=UTF-8">
</cffunction>

<cffunction name="CreateXmlHeader" returntype="void" output="true">
	<cfargument name="command" required="true">
	<cfargument name="resourceType" required="true">
	<cfargument name="currentFolder" required="true">

	<cfset SetXmlHeaders()>
	<cfoutput><?xml version="1.0" encoding="utf-8" ?></cfoutput>
	<cfoutput><Connector command="#ARGUMENTS.command#" resourceType="#ARGUMENTS.resourceType#"></cfoutput>
	<cfoutput><CurrentFolder path="#HTMLEditFormat(ARGUMENTS.currentFolder)#" url="#HTMLEditFormat( GetUrlFromPath( resourceType, currentFolder, command ) )#" /></cfoutput>
	<cfset REQUEST.HeaderSent = true>
</cffunction>

<cffunction name="CreateXmlFooter" returntype="void" output="true">
	<cfoutput></Connector></cfoutput>
</cffunction>

<cffunction name="SendError" returntype="void" output="true">
	<cfargument name="number" required="true" type="Numeric">
	<cfargument name="text" required="true">
	<cfif isDefined("REQUEST.HeaderSent") and REQUEST.HeaderSent>
		<cfset SendErrorNode( ARGUMENTS.number, ARGUMENTS.text )>
		<cfset CreateXmlFooter() >
	<cfelse>
		<cfset SetXmlHeaders()>
		<cfoutput><?xml version="1.0" encoding="utf-8" ?></cfoutput>
		<cfoutput><Connector></cfoutput>
		<cfset SendErrorNode( ARGUMENTS.number, ARGUMENTS.text )>
		<cfset CreateXmlFooter() >
	</cfif>
	<cfabort>
</cffunction>

<cffunction name="SendErrorNode" returntype="void" output="true">
	<cfargument name="number" required="true" type="Numeric">
	<cfargument name="text" required="true">
	<cfoutput><Error number="#ARGUMENTS.number#" text="#htmleditformat(ARGUMENTS.text)#" /></cfoutput>
</cffunction>
