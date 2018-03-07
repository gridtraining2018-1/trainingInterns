function (e,val)
{ var t =Number(val)+ 7;
	var e ;
	var out ='';
	e=document.getElementById('avlAndFareForm:trainbtwnstns').getElementsByTagName('tr');
	if(e!=null)
	{for(var i=1;i<e.length-1;i++)
{   
  var e2= e[i].getElementsByTagName('td');
   var c =e2[t].getElementsByTagName('img')[0].className;
   
   if(c=='train-running')
   {out += e2[0].getElementsByTagName('a')[0].innerHTML +" ";  
   
   }
	   
}

return out ;
	}
	else
		return f ;
}