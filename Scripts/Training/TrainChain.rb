require 'oj'

Oj.default_options = {:escape_mode => :ascii, :indent => 4}

emoji = File.read("Corpus-Emoji.txt")
parts = File.read("Corpus-Parts.txt")
map = {
    "NN" => [],
    "VB" => [],
    "WH" => [],
    "CD" => [],
    "AJ" => []
}

emoji_lines = emoji.split("\n")
parts_lines = parts.split("\n")

last_key = ""
map[""] = {
    "pos" => [ ],
    "sym" => [ ]
}

line = 0
emoji_lines.each do |icon|
    posts = parts_lines[line].split(" ")
    icons = icon.split(" ")
    symbol = 0
    icons.each do |sym|
        if map.key? last_key
            map[last_key]["pos"].push posts[symbol]
            map[last_key]["sym"].push sym
            map[last_key]["pos"].uniq!
            map[last_key]["sym"].uniq!
        else
            map[last_key] = {
                "pos" => [ posts[symbol] ],
                "sym" => [ sym ]
            }
        end
        last_key = sym
        symbol += 1
    end
    last_key = ""
    line += 1
end
Oj.to_file("Chain.json", map)