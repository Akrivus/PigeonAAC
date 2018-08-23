require 'oj'
Oj.default_options = {:escape_mode => :ascii, :indent => 4}
seq = File.read("Corpus-English-Seq.txt").split(" ")
eng_pool = Oj.load_file("PosPool-English.json")
pid_pool = Oj.load_file("PosPool-Pidgin.json")
table = Oj.load_file("Table.json")
sequence = []
input = File.read("Arguments.txt").force_encoding("UTF-8")
words = input.split(" ")
words.each do |word|
    sequence.push({"pid" => word, "pos" => pid_pool[word]})
end
cus = []
sequence.each do |word|
    cus.push word["pos"]
end
del = []
seq.each do |pos|
    if not cus.include? pos
        del.push pos
    end
end
del.each do |pos|
    seq.delete pos
end
ideal = (0..seq.length-1).to_a
other = []
cus.each do |pos|
    other.push seq.index(pos)
end
swaps = []
i = 0
ideal.each do |idea|
    if other[i] != idea
        swaps.push idea
    end
    i += 1
end
swaps.length.times do
    swaps.each do |swap|
        sequence[seq.index(cus[swap])], sequence[swap] = sequence[swap], sequence[seq.index(cus[swap])]
        swaps.delete seq.index(cus[swap])
        swaps.delete swap
    end
end
sequence.each do |part|
    print table[part["pid"]] + " "
end