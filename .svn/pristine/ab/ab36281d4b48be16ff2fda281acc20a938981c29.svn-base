<cfsetting enablecfoutputonly="yes" showdebugoutput="no">


<cfparam name="url.type" default="File">
<cfparam name="url.currentFolder" default="/">

<!--- note: no serverPath url parameter - see config.cfm if you need to set the serverPath manually --->

<cfinclude template="config.cfm">
<cfinclude template="cf_util.cfm">
<cfinclude template="cf_io.cfm">
<cfinclude template="cf_commands.cfm">

<cffunction name="SendError" returntype="void" output="true">
	<cfargument name="number" required="true" type="Numeric">
	<cfargument name="text" required="true">
	<cfreturn SendUploadResults( "#ARGUMENTS.number#", "", "", "ARGUMENTS.text" )>
</cffunction>

<cfset REQUEST.Config = Config>
<cfif find( "/", getBaseTemplatePath() ) >
	<cfset REQUEST.Fs = "/">
<cfelse>
	<cfset REQUEST.Fs = "\">
</cfif>

<cfif not Config.Enabled>
	<cfset SendUploadResults( '1', '', '', 'This file uploader is disabled. Please check the "editor/filemanager/connectors/cfm/config.cfm" file' )>
</cfif>

<cfset sCommand = 'QuickUpload'>
<cfset sType = "File">

<cfif isDefined( "URL.Type" )>
	<cfset sType = URL.Type>
</cfif>

<cfset sCurrentFolder = GetCurrentFolder()>

<!--- Is enabled the upload? --->
<cfif not IsAllowedCommand( sCommand )>
	<cfset SendUploadResults( "1", "", "", "The """ & sCommand & """ command isn't allowed" )>
</cfif>

<!--- Check if it is an allowed type. --->
<cfif not IsAllowedType( sType )>
	<cfset SendUploadResults( "1", "", "", "Invalid type specified" ) >
</cfif>

<cfset FileUpload( sType, sCurrentFolder, sCommand )>
