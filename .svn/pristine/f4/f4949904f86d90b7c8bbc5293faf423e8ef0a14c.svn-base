

sub RemoveFromStart
{
	local($sourceString, $charToRemove) = @_;
	$sPattern = '^' . $charToRemove . '+' ;
	$sourceString =~ s/^$charToRemove+//g;
	return $sourceString;
}

sub RemoveFromEnd
{
	local($sourceString, $charToRemove) = @_;
	$sPattern = $charToRemove . '+$' ;
	$sourceString =~ s/$charToRemove+$//g;
	return $sourceString;
}

sub ConvertToXmlAttribute
{
	local($value) = @_;
	return $value;
#	return utf8_encode(htmlspecialchars($value));

}

sub specialchar_cnv
{
	local($ch) = @_;

	$ch =~ s/&/&amp;/g;		# &
	$ch =~ s/\"/&quot;/g;	#"
	$ch =~ s/\'/&#39;/g;	# '
	$ch =~ s/</&lt;/g;		# <
	$ch =~ s/>/&gt;/g;		# >
	return($ch);
}

sub JS_cnv
{
	local($ch) = @_;

	$ch =~ s/\"/\\\"/g;	#"
	return($ch);
}

1;
