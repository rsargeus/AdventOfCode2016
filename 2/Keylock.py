import sys,os

def Down():
    global x    
    if x < 2 :
        x = x+1

def Up():
    global x    
    if x > 0 :
        x = x-1

def Right():
    global y    
    if y < 2 :
        y = y+1

def Left():
    global y    
    if y > 0 :
        y = y-1

def GetNumber(instr) :
    
    for c in instr :
        if c == "U" :
            Up()
        if c == "D" :
            Down()
        if c == "L" :
            Left()
        if c == "R" :
            Right()
    return matrix[x][y]

#Defining matrix
matrix = [[1,2,3], [4,5,6], [7,8,9]]

#Starting point
x = 1;
y = 1;

f = open(os.path.abspath("2\input.txt"), encoding='utf-8') 

while True:
    
    line = f.readline()
    if not line: 
        break
    n = GetNumber(line)
    sys.stdout.write(str(n) + " ")    