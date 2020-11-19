

def genList
  Array.new(50).map {
    rand(100)
  }
end

def linerSearch(targetNum, randList, index)
  if targetNum === randList[0] then
    return index
  elsif randList === [] then
    return -1
  else
    linerSearch(targetNum, randList.drop(1), index+1)
  end
end

def main
  list = genList()
  p list
  linerSearch(10, list, 0)
end
