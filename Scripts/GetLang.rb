require 'oj'
arg = File.read("Arguments.txt").force_encoding("UTF-8")
translation = ""
map = Oj.load_file("Lang.json")
arg.split(" ").each do |e|
    if map.key? e
        translation += map[e].sample + " "
    end
end
print translation