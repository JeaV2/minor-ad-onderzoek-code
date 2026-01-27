use std::io;
use std::fs;

fn main() {
    hello_world();
    hello_name();
    loop_example();
    print_filenames_dir().expect("Failed to print filenames");
}

fn hello_world() {
    const HELLOWORLD: &str = "Hello world as a const!";
    // HELLOWORLD = "Modified hello world!";
    println!("{}", HELLOWORLD);
    let mut __hello_let: &str = "Hello world!";
    __hello_let = "Hello world as a let!";
    println!("{}", __hello_let);
}

fn hello_name() {
    let mut input = String::new();
    println!("Please enter your name:");
    io::stdin()
        .read_line(&mut input)
        .expect("Failed to read line");
    println!("Hello, {}", input.trim());
}

fn loop_example() {
    let mut loops_input = String::new();
    println!("Enter a number to count up to:");
    io::stdin()
        .read_line(&mut loops_input)
        .expect("Failed to read line");
    let loops_input: u32 = loops_input.trim().parse().expect("Please enter a valid number");
    for n in 1..=loops_input {
        println!("Number: {n}")
    }
}

fn print_filenames_dir() -> io::Result<()> {
    let entries = fs::read_dir(".")?;
    for entry in entries {
        let entry = entry?;
        let filename = entry.file_name();
        println!("{}", filename.to_string_lossy());
    }
    Ok(())
}