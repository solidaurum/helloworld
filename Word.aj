package HelloWorld;

public aspect Word {


	pointcut formater(String p): call(void java.io.PrintStream.*(..)) && args(p);
	pointcut correcter(String i): call(void *.format(..)) && args(i);
	pointcut avatar():call(void *.eatHelloWorld());

	Object around(String p):formater(p){
		String[] j = p.split(" ");
		
		for(int k = 0; k < j.length; k++){
			switch(j[k]){
			case "bcoz":
				j[k]="because";
				break;
			case "i":
				j[k]="I";
				break;
			case "b4":
				j[k]="before";
				break;
			case "BFN":
				j[k]="Good bye";
			case "fab":
				j[k]="fabulous";
				break;
			case "u":
				j[k]="you";
				break;
			default:
				break;
			}
		}
		
		p="";
		for(int k = 0; k<j.length; k++){
			p+=j[k]+" ";
		}
		
		return proceed(p);
	}
	Object around(String i):correcter(i){
		String[] j = i.split(" ");
		
		for(int k = 0; k < j.length; k++){
			switch(j[k]){
			case "bcoz":
				j[k]="because";
				break;
			case "i":
				j[k]="I";
				break;
			case "b4":
				j[k]="before";
				break;
			case "BFN":
				j[k]="Good bye";
			case "fab":
				j[k]="fabulous";
				break;
			case "u":
				j[k]="you";
				break;
			default:
				break;
			}
		}
		
		i="";
		for(int k = 0; k<j.length; k++){
			i+=j[k]+" ";
		}
		
		return proceed(i);
	}
	before():avatar(){
		System.out.println("say it aint sooo, bcoz u don't know me \n nooooooo");
	}

}
