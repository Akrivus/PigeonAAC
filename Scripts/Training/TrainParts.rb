require 'oj'

Oj.default_options = {:escape_mode => :ascii, :indent => 4}

emoji = File.read("Corpus-Emoji.txt")
parts = File.read("Corpus-Parts.txt")
map = {}

emoji_lines = emoji.split("\n")
parts_lines = parts.split("\n")

line = 0
emoji_lines.each do |icon|
    posts = parts_lines[line].split(" ")
    icons = icon.split(" ")
    symbol = 0
    icons.each do |sym|
        if map.key? posts[symbol]
            map[posts[symbol]].push sym
            map[posts[symbol]].uniq!
        end
        symbol += 1
    end
    line += 1
end
Oj.to_file("Parts.json", map)