$content = Get-Content .\input.txt

$count = 0;

foreach($line in $content) {
    
    $values = $line.Split(" ",[System.StringSplitOptions]::RemoveEmptyEntries)
     
    [int]$a = [convert]::ToInt32($values[0], 10) 
    [int]$b = [convert]::ToInt32($values[1], 10) 
    [int]$c = [convert]::ToInt32($values[2], 10) 
    
    if(($a + $b) -gt $c){
        $count++;
    }
}

Write-Host $count " possible triangles"