package HelloWorld;

public class HelloWorld {
	public static void main(String[] args){
		displayText("I love you bcoz your cute");
		String hello = "i love u bcoz your cute\n";
		System.out.print(hello);
		eatHelloWorld();
	}
	
//	public static void sayHello(){
//		System.out.println("Hello");
//	}
	public static void displayText(String i){
		System.out.println(i);
		
	}
	
	public static void eatHelloWorld(){
		System.out.println("u have 30 seconds to close this\n"
				+ "before your little perfect world will be eaten.");
	}
	
}