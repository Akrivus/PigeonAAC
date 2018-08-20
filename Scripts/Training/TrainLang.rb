require 'oj'

Oj.default_options = {:escape_mode => :ascii, :indent => 4}

english = File.read("Corpus-English.txt")
emoji = File.read("Corpus-Emoji.txt")
map = {}

english_lines = english.split("\n")
emoji_lines = emoji.split("\n")

line = 0
english_lines.each do |sentence|
    icons = emoji_lines[line].split(" ")
    words = sentence.split(" ")
    icon = 0
    words.each do |word|
        if icons[icon].nil?
            word = words[(icon - 1)..words.length].join(" ")
            if map.key? icons[icon - 1]
                map[icons[icon - 1]][map[icons[icon - 1]].length - 1] = word 
                map[icons[icon - 1]].uniq!
            else
                map[icons[icon - 1]] = [ word ]
            end
        else
            if map.key? icons[icon]
                map[icons[icon]].push word
                map[icons[icon]].uniq!
            else
                map[icons[icon]] = [ word ]
            end
        end
        icon += 1
    end
    line += 1
end
Oj.to_file("Lang.json", map)