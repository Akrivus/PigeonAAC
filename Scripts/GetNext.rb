require 'oj'
Oj.default_options = {:escape_mode => :ascii, :indent => 4}
seq = File.read("Corpus-Pidgin-Seq.txt").force_encoding("UTF-8").split(" ")
pool = Oj.load_file("PosPool-Pidgin.json")
input = File.read("Arguments.txt").force_encoding("UTF-8")
dest = seq.index(pool[input])
if dest.nil?
    dest = seq[0]
else
    dest = seq[dest + 1]
end
output = []
pool.each do |word, pos|
    if pos == dest
        output.push word
    end
end
print output.join(",")