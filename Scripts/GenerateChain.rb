require 'oj'
Oj.default_options = {:escape_mode => :ascii, :indent => 4}
["English", "Pidgin"].each do |lang|
    markov_chain = {}
    pid_lines = File.read("Corpus-" + lang + ".txt").split("\n")
    pid_lines.each do |line|
        pid_words = line.split(" ")
        last_key = ""
        pid_words.each do |word|
            if markov_chain.key? last_key
                markov_chain[last_key].push word
            else
                markov_chain[last_key] = [
                    word
                ]
            end
            last_key = word
        end
        if markov_chain.key? last_key
            markov_chain[last_key].push "."
        else
            markov_chain[last_key] = [
                "."
            ]
        end
    end
    Oj.to_file("MarkovChain-" + lang + ".json", markov_chain)
end