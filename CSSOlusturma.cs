private string cssClassDiv(string css_verisi){
  Regex reg = new Regex(@"\.([a-z\-]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);

  string sonuc = "";
  
  foreach (var cssClass in reg.Matches(css_verisi))
  {
    sonuc += "<div class=\"" + cssClass.ToString().Remove(0, 1) + "\">" + cssClass.ToString().Remove(0, 1) + "</div>\n";
  }
  
  return sonuc;
}
