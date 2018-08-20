require 'oj'
e = File.read("Arguments.txt").force_encoding("UTF-8")
pos = ""
colors = Oj.load_file("Colors.json")
parts = Oj.load_file("Parts.json")
parts.each do |part, array|
    array.each do |emoji|
        if emoji == e
            pos = part
        end
    end
end
print colors[pos]