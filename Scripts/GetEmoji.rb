require 'oj'
e = File.read("Arguments.txt").force_encoding("UTF-8")
map = Oj.load_file("Chain.json")
if not map.key? e
    print map[""]["sym"].join(",")
else
    parts = Oj.load_file("Parts.json")
    a = map[e]["sym"]
    p = []
    map[e]["pos"].each do |pos|
        p = p.concat(parts[pos])
    end
    a = a.concat(p)
    a.delete(e)
    a.uniq!
    print a.join(",")
end