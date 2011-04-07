Sloppy
====

A .Net version of the Slop gem for ruby 

https://github.com/injekt/slop

Usage 
-----

	parser = Slop.New()
				.Options('a',"all", "automatically stage files");
	dynamic arguments = parser.Parse(args);
	
	bool hasAll = arguments.HasAll;
	object value = arguments.All;
				
