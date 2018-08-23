require 'oj'
Oj.default_options = {:escape_mode => :ascii, :indent => 4}
pool = Oj.load_file("PosPool-Pidgin.json")
colors = Oj.load_file("PosColors.json")
input = File.read("Arguments.txt").force_encoding("UTF-8")
input = input.gsub(/\s/, "")
print colors[pool[input]]