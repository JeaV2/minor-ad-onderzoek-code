import os


def main():
    dir = input("Enter directory path: (leave empty for current directory) ")
    if not dir:
        dir = '.'
    print(f"Current working directory: {os.getcwd()}")
    files = os.listdir(dir)
    print(f"Files in the directory {dir}:")
    for file in files:
        print(f"- {file}, directory: {os.path.isdir(os.path.join(dir, file))}")


if __name__ == "__main__":
    main()
